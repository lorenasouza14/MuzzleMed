import api from '../api';

export const createSchedules = async () => {
  try {
    const response = await api.post('/api/AppointmentsSchedulesContext/create');
    return response.data;       
    } catch (error) {
    console.error("Erro ao criar agendamento:", error);
    throw error; 
  }
};

/*
{
  "userId": "f50a7cd3-4294-41db-bb3e-42e18523968e",
  "petId": "0bbe11d8-75b6-4e64-bef9-906ad45ee3a2",
  "clinicId": "6c4d8da4-a3f1-46e8-bea0-f7f6191a10ce",
  "vetId": "08dec3cf-5bd5-44d3-8b41-c6195eb1ee45",
  "date": "2026-06-08",
  "time": "15:00:00",
  "status": 0
}

*/ 