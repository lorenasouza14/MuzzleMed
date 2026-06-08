import axios from 'axios';

const api = axios.create({
    baseURL: 'https://localhost:5001',
});

//Envia o token de autentificacao para as outras rotas da API
api.interceptors.request.use((config) => {
    const user = localStorage.getItem("user");
    
    if (user) {
        const userData = JSON.parse(user);
        
        if (userData && userData.token) {
            config.headers.Authorization = `Bearer ${userData.token}`;
        }
    }
    
    return config;
}, (error) => {
    return Promise.reject(error);
});

export default api;