import api  from "../api"; 

export const bookTime = async (scheduleData) => {
    try {
        const response = await api.post('/api/BookTime/register', scheduleData);

        return response.data;
    }

    catch (error) {
        console.error("Erro ao criar agendamento:", error);
        throw error; 
    }
};
