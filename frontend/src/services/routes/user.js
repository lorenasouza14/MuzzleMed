import api from '../api';


export const createUser = async (userData) => {
  try {
    const response = await api.post('/api/v1/users', userData);
    return response.data;

  } catch (error) {
    console.error("Erro ao criar usuário:", error);
    throw error;
  }
};

export const getUser = async () => {  
  try {
    const response = await api.get(`/api/v1/users/user`);
    return response.data;   
}
     catch (error) {
    console.error("Erro ao buscar usuário:", error);
    throw error;
  }};