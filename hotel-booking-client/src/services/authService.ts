import apiInstance from '../api/axiosConfig';
import type {RegisterUserDto, LoginUserDto} from '../types/auth';

const register = (userData: RegisterUserDto) => {
    return apiInstance.post(`/auth/register`, userData);
};

const login = (userData: LoginUserDto) => {
    return apiInstance.post(`/auth/login`, userData);
};

const authService = {
    register,
    login,
};

export default authService;