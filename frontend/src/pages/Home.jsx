import '../styles/Home.css';
import Title from "../components/Title/Title";
import Navbar from "../components/NavBar/NavBar";
import CarouselConsultation from '../components/CarouselConsultation/CarouselConsultation';
import ListLatestConsultations from "../components/ListLatestConsultations/ListLatestConsultations";
import BranchList from "../components/BranchList/BranchList"; 
import { getUser } from "../services/routes/user";
import { getSchedules, cancelSchedule, getHistoricByPetId } from "../services/routes/schedule";
import { useState, useEffect } from 'react';
import { getPets } from "../services/routes/pet";

function Home() {
    const [user, setUser] = useState("");
    const [consultations, setConsultations] = useState([]);
    const [historyList, setHistoryList] = useState([]);

    useEffect(() => {
        const fetchHomeData = async () => {
            try {
                const userData = await getUser();
                setUser(userData);

                const schedulesData = await getSchedules();

                const listaSegura = Array.isArray(schedulesData) ? schedulesData : [];

                const formattedSchedules = listaSegura.map(schedule => {
                    const dataRaw = schedule.date || schedule.Date || "";
                    const vetData = schedule.vetName || schedule.VetName;
                    let dataFormatada = "Data a definir";

                    if (dataRaw) {
                        const apenasData = dataRaw.split('T')[0]; 
                        if (apenasData.includes('-')) {
                            const [ano, mes, dia] = apenasData.split('-');
                            dataFormatada = `${dia}/${mes}/${ano}`;
                        } else {
                            dataFormatada = dataRaw;
                        }
                    }
                    const horaRaw = schedule.time || schedule.Time || "";
                    let horaFormatada = "Horário a definir";

                    if (horaRaw) {
                        const partesHora = horaRaw.split(':');
                        if (partesHora.length >= 2) {
                            horaFormatada = `${partesHora[0]}:${partesHora[1]}`;
                        } else {
                            horaFormatada = horaRaw;
                        }
                    }

                    return {
                        id: schedule.id || schedule.Id,    
                        namePet: schedule.petName || schedule.PetName || "Pet cadastrado", 
                        date: dataFormatada, 
                        time: horaFormatada,
                        symptoms: schedule.symptomDescription || schedule.SymptomDescription || "Sem sintomas descritos",
                        location: schedule.clinicName || schedule.ClinicName || "Unidade selecionada",
                        veterinarian: vetData?.fullName || (typeof vetData === 'string' ? vetData : "Profissional"),
                        status: schedule.status || schedule.Status || "aberto"
                    };
                });

                const consultasAtivas = formattedSchedules.filter(consulta => {
                    const status = consulta.status?.toLowerCase() || "";
                    return status !== "canceled" && status !== "completed" && status !== "concluido";
                });

                setConsultations(consultasAtivas);

                const petsData = await getPets();
                const petsArray = Array.isArray(petsData) ? petsData : [];
                const historicosPromises = petsArray.map(pet => getHistoricByPetId(pet.id));
                const historicosResultados = await Promise.all(historicosPromises);
                const todosHistoricos = historicosResultados.flat();
                setHistoryList(todosHistoricos);

            } catch (error) {
                console.error("Erro ao carregar dados da Home:", error);
            }
        };

        fetchHomeData();
    }, []);

    const handleCancelAppointment = async (id) => {
        if (window.confirm("Tem certeza que deseja cancelar este agendamento?")) {
            try {
                await cancelSchedule(id);
                setConsultations(prevConsultations => prevConsultations.filter(c => c.id !== id));
                
                alert("Agendamento cancelado com sucesso!");
            } catch (error) {
                console.error(error);
                alert("Erro ao cancelar agendamento. Tente novamente.");
            }
        }
    };

    return (
        <main className="container-hm">
            <Navbar />
            <div className="box-hm">
                <div className='column-hm'>

                    <Title
                        title={`Olá, ${user?.fullName || 'usuário'}! Veja as Próximas Consultas`}
                        showButton={false}
                        showCloseButton={false}
                    />

                    {/* Verificação condicional para renderizar o carrossel ou a mensagem */}
                    {consultations.length > 0 ? (
                        <CarouselConsultation 
                            consultations={consultations} 
                            onCancelAppointment={handleCancelAppointment} 
                        />
                    ) : (
                        // Esta é a parte que mudou: adicionamos um container azul para a mensagem
                        <div 
                            style={{ 
                                backgroundColor: "#e6f7ff", // <--- COR DE FUNDO AZUL (pode alterar o hexadecimal)
                                padding: "40px",              // Espaçamento interno para a mensagem não ficar colada na borda
                                borderRadius: "10px",        // Arredonda as bordas para combinar com outros elementos
                                textAlign: "center",         // Centraliza o texto
                                marginTop: "20px",           // Espaçamento superior
                                marginBottom: "20px"         // Espaçamento inferior
                            }}
                        >
                            <p style={{ color: "#666", fontSize: "16px", margin: 0 }}>
                                Não há consultas agendadas.
                            </p>
                        </div>
                    )}

                    <Title
                        title="Histórico Veterinário"
                        showButton={false}
                        showCloseButton={false}
                    />

                    <div className="history-list-wrapper">
                        {historyList.length > 0 ? (
                            historyList.map((hist, index) => {
                                const dataRaw = hist.date || hist.Date || "";
                                const apenasData = dataRaw.split('T')[0];
                                const dataFormatada = apenasData.includes('-') 
                                    ? apenasData.split('-').reverse().join('/') 
                                    : apenasData;
                                const vetData = hist.vetName || hist.VetName;
                                const nomeVet = vetData?.fullName || (typeof vetData === 'string' ? vetData : "Profissional");
                                const medData = hist.medication || hist.Medication;
                                let medFormatada = "Sem medicação informada";
                                
                                if (Array.isArray(medData) && medData.length > 0) {
                                    medFormatada = medData.map((medicamento, i) => (
                                        <span key={i} style={{ display: "block", marginBottom: "4px" }}>
                                            • {medicamento}
                                        </span>
                                    )); 
                                } else if (typeof medData === 'string') {
                                    medFormatada = <span style={{ display: "block" }}>• {medData}</span>;
                                }

                                return (
                                    <ListLatestConsultations 
                                        key={hist.id || index} 
                                        namePet={hist.petName || hist.PetName || "Pet cadastrado"} 
                                        dateConsultation={dataFormatada} 
                                        symptoms={hist.diagnostic || hist.Diagnostic || "Sem diagnóstico"} 
                                        medication={medFormatada} 
                                        location={hist.clinicName || hist.ClinicName || "Unidade não informada"} 
                                        veterinarian={nomeVet} 
                                        status={hist.status || hist.Status || "Concluído"} 
                                    />
                                );
                            })
                        ) : (
                            <p style={{ textAlign: "center", color: "#666" }}>Nenhum histórico encontrado para os seus pets.</p>
                        )}
                    </div>
                </div>

                <BranchList />
            </div>
        </main>
    );
}

export default Home;