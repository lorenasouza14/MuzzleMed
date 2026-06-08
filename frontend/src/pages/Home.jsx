
import '../styles/Home.css';
import Title from "../components/Title/Title";
import Navbar from "../components/NavBar/NavBar";
import CarouselConsultation from '../components/CarouselConsultation/CarouselConsultation';
import ListLatestConsultations from "../components/ListLatestConsultations/ListLatestConsultations";
import BranchList from "../components/BranchList/BranchList"; 
import { getUser } from "../services/routes/user";
import { useState } from 'react';


function Home() {
    const [user, setUser] = useState("");

        useState(() => {
            const fetchUser = async () => {
                try {
                    const data = await getUser();
                    setUser(data);
                } catch (error) {
                    console.error("Erro ao buscar usuário:", error);
                }
            };

            fetchUser();
        }, []);

    const mockConsultations = [
        { namePet: "Pituffinho", date: "19/05/2026", time: "09:30", symptoms: "Coceira intensa nas costas...Coceira intensa nas costas..Coceira intensa nas costas..", location: "Clínica LevaAUqui", veterinarian: "Roberto Caulos" },
        { namePet: "Pituffinho", date: "19/05/2026", time: "10:30", symptoms: "Tosse e espirro constante", location: "Clínica LevaAUqui", veterinarian: "Roberto Caulos" },
        { namePet: "Pituffinho", date: "19/05/2026", time: "11:30", symptoms: "Febre baixa", location: "Clínica LevaAUqui", veterinarian: "Roberto Caulos" },
        { namePet: "Pituffinho", date: "19/05/2026", time: "14:00", symptoms: "Revisão geral", location: "Clínica LevaAUqui", veterinarian: "Roberto Caulos" },
        { namePet: "Pituffinho", date: "19/05/2026", time: "16:00", symptoms: "Vacinação", location: "Clínica LevaAUqui", veterinarian: "Roberto Caulos" },
    ];

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

                    <CarouselConsultation consultations={mockConsultations} />

                   

                    <Title
                        title="Histórico Veterinário"
                        showButton={false}
                        showCloseButton={false}
                    />

                    <div className="history-list-wrapper">
                        <ListLatestConsultations namePet="Pituffinho" dateConsultation="01/02/2026" symptoms="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever sin" medication="1 pastilha Agemoxi CL por dia" location="São Paulo" veterinarian="Fernado Reis" status="Concluido" />

                        <ListLatestConsultations namePet="Pituffinho" dateConsultation="01/02/2026" symptoms="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever sin" medication="1 pastilha Agemoxi CL por dia" location="São Carlos" veterinarian="Fernado Reis" status="Concluido" />

                        <ListLatestConsultations namePet="Pituffinho" dateConsultation="01/02/2026" symptoms="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever sin" medication="1 pastilha Agemoxi CL por dia" location="São Carlos" veterinarian="Fernado Reis" status="Concluido" />
                    </div>
                </div>

                <BranchList />

            </div>

           
            
        </main>
    );
}

export default Home;