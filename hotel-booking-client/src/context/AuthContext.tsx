import { createContext, useContext, useEffect, useState } from "react";
import { jwtDecode } from "jwt-decode";

interface User {
    sub: string;
    email: string;
}

interface AuthContextType {
    user: User | null;
    token: string | null;
    login: (newToken: string) => void;
    logout: () => void;
}

const AuthContext = createContext<AuthContextType | undefined>(undefined);

interface AuthProviderProps {
    children: React.ReactNode;
}

export const AuthProvider = ({ children }: AuthProviderProps) => {
    const [user, setUser] = useState<User | null>(null);
    const [token, setToken] = useState<string | null>(null);

    useEffect(() => {
        const storedToken = localStorage.getItem("token");
        if (storedToken) {
            try {
                const decodedUser = jwtDecode<User>(storedToken);
                setUser(decodedUser);
                setToken(storedToken);
            } catch (error) {
                localStorage.removeItem("token"); // Clear invalid token
            }
        }
    }, []);

    const login = (newToken: string) => {
        try {
            const decodedUser = jwtDecode<User>(newToken);
            localStorage.setItem("token", newToken);
            setUser(decodedUser);
            setToken(newToken);
        } catch (error) {
            console.error("Failed to decode token:", error);
        }
    };

    const logout = () => {
        localStorage.removeItem("token");
        setUser(null);
        setToken(null);
    };

    const value = { user, token, login, logout };

    return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>;
};

export const useAuth = () => {
    const context = useContext(AuthContext);
    if (context === undefined) {
        throw new Error("useAuth must be used within an AuthProvider");
    }
    return context;
};