import axios from "axios";
import type {RegisterUserDto, LoginUserDto} from '../types/auth';

// TODO: Add API_URL to .env file
const API_URL = 'http://localhost:5297/api/auth';

const register = (userData: RegisterUserDto) => {
    return axios.post(`${API_URL}/register`, userData);
};

const login = (userData: LoginUserDto) => {
    return axios.post(`${API_URL}/login`, userData);
};

const authService = {
    register,
    login,
};

export default authService;