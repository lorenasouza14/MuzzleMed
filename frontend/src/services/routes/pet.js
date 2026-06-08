import api from '../api';

//Falta o delete PET e o update PET

export const getPets = async () => {
  try {
    const response = await api.get('/api/v1/pets');
    return response.data; 

  } catch (error) {
    console.error("Erro ao buscar pets:", error);
    throw error; 
  }
};

export const createPet = async (petData) => {
  try {
    const response = await api.post('/api/v1/pets', petData);
    return response.data;

  } catch (error) {
    console.error("Erro ao criar pet:", error);
    throw error;
  }
};