import api from '../api';

export const getClinics = async () => {
  try {
    const response = await api.get('/api/Clinic');
    return response.data; 

  } catch (error) {
    console.error("Erro ao buscar clínicas:", error);
    throw error; 
  }
};