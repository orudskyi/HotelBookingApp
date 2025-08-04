import axios from "axios";

// TODO: Add API_URL to .env file
const API_URL = 'https://localhost:7123/api';

const apiInstance = axios.create({
    baseURL: API_URL,
});

apiInstance.interceptors.request.use(
    (config) => {
        const token = localStorage.getItem('token');
        if (token) {
            config.headers.Authorization = `Bearer ${token}`;
        }
        return config;
    },
    (error) => {
        return Promise.reject(error);
    }
);

export default apiInstance;