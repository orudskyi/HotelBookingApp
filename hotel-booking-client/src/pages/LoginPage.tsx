import { useState, type FormEvent } from "react";
import { useNavigate } from "react-router-dom";
import authService from "../services/authService";
import { useAuth } from "../context/AuthContext";

const LoginPage = () => {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [error, setError] = useState<string | null>(null);
    
    const navigate = useNavigate();
    const { login } = useAuth();

    const handleSubmit = async (event: FormEvent) => {
        event.preventDefault(); // Prevents the default form submission (page reload)
        setError(null); // Clear previous errors

        try {
            const response = await authService.login({ email, password });
            login(response.data.token); // Use the login function from AuthContext
            console.log('Login successful, context updated.');
            navigate('/');
            
        } catch (err: any) {
            console.error('Login failed:', err.response?.data);
            setError('Failed to log in. Please check your email and password.');
        }
    };

    return (
        <div>
            <h1>Login</h1>
            <form onSubmit={handleSubmit}>
                <div>
                    <label htmlFor="email">Email:</label>
                    <input
                        id="email"
                        type="email"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        required
                    />
                </div>
                <div>
                    <label htmlFor="password">Password:</label>
                    <input
                        id="password"
                        type="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        required
                    />
                </div>
                {error && <p style={{ color: 'red' }}>{error}</p>}
                <button type="submit">Login</button>
            </form>
        </div>
    );
};

export default LoginPage;