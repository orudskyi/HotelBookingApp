import { Navigate } from "react-router-dom";
import { useAuth } from "../context/AuthContext";

interface ProtectedRouteProps {
  children: React.ReactNode;
}

const ProtectedRoute = ({ children }: ProtectedRouteProps) => {
    const { user } = useAuth();

    if (!user) {
        // If the user is not authenticated, redirect to the login page
        return <Navigate to="/login" />;
    }

    // If the user is authenticated, render the child components
    return <>{children}</>;
    };

    export default ProtectedRoute;