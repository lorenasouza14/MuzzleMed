import api from '../api';

export const createSchedules = async (appointment) => {
  try {
    const response = await api.post('/api/AppointmentScheduleContext/create', appointment);
    return response.data;
  } catch (error) {
    console.error("Erro ao criar agendamento:", error);
    throw error; 
  }
};

export const getSchedules = async () => {
  try {
    const response = await api.get('/api/AppointmentScheduleContext');
    return response.data;
  } catch (error) {
    console.error("Erro ao buscar agendamento:", error);
    throw error;
  }
};

export const cancelSchedule = async (id) => {
  try {
        const response = await api.put(`/api/AppointmentScheduleContext/cancel/${id}`);
        return response.data;
    } catch (error) {
        throw error;
    }
};

export const getHistoricByPetId = async (petId) => {
    try {
        const response = await api.get(`/api/HistoricAppointment/pet/${petId}`);
        return response.data;
    } catch (error) {
        console.error("Erro ao buscar histórico do pet:", error);
        return []; 
    }
};