
import api from '../api';


api.interceptors.request.use((config) => {
    const user = localStorage.getItem("user");
    
    if (user) {
        const userData = JSON.parse(user);
        
        if (userData.token) {
            config.headers.Authorization = `Bearer ${userData.token}`;
        }
    }
    
    return config;
}, (error) => {
    return Promise.reject(error);
});

export default api;