import { useAuth } from "../context/AuthContext";

const ProfilePage = () => {
    const { user } = useAuth();

    return (
        <div>
            <h1>Your Profile</h1>
            <p>Welcome, {user?.email}!</p>
            <p>Your User ID is: {user?.sub}</p>
        </div>
    );
}

export default ProfilePage;