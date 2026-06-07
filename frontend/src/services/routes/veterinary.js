import api from '../api';

export const getVets = async () => {
  try {
    const response = await api.get('/api/vets');
    return response.data; 

  } catch (error) {
    console.error("Erro ao buscar veterinários:", error);
    throw error; 
  }
};

export const getVetById = async (id) => {
  try {
    const response = await api.get(`/api/vets/${id}`);
    return response.data; 
  } catch (error) {
    console.error(`Erro ao buscar veterinário com ID ${id}:`, error);
    throw error; 
  }
};