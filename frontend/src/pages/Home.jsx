// import '../styles/Home.css';
// import Title from "../components/Title/Title";
// import Navbar from "../components/NavBar/NavBar";
// import CardConsultation from "../components/CardConsultation/CardConsultation";
// import ListLatestConsultations from "../components/ListLatestConsultations/ListLatestConsultations";

// function Home() {
//     return (
//         <main className="container-hm">
//             <Navbar />
//             <div className="box-hm">
//                 <div className='column-hm'>
//                     <Title children={"Próximas Consultas"} />
//                     <div className="row-consultation-hm">

//                         <CardConsultation namePet="Rex" date="2024-07-01" time="14:00" symptoms="Tosse e falta de apetite, e vômito" location="Clínica Veterinária Central" veterinarian="Dr. Silva" />

//                         <CardConsultation namePet="Rex" date="2024-07-01" time="14:00" symptoms="Tosse e falta de apetite" location="Clínica Veterinária Central" veterinarian="Dr. Silva" />

//                     </div>
//                     <Title children={"Histórico Veterinário"} />


//                     <ListLatestConsultations namePet="Pituffinho" dateConsultation="25/04/2026" symptoms="Febre, tosse e espirros constantes" medication="1 pastilha  Agemoxi CL por dia" location="MiarCuidados" veterinarian="Roberto Carlos" status="Concluída" />

//                     {/* <ListLatestConsultations namePet="Pituffinho" dateConsultation="25/04/2026" symptoms="Febre, tosse e espirros constantes" medication="1 pastilha  Agemoxi CL por dia" location="MiarCuidados" veterinarian="Roberto Carlos" status="Concluída" />

//                     <ListLatestConsultations namePet="Pituffinho" dateConsultation="25/04/2026" symptoms="Febre, tosse e espirros constantes" medication="1 pastilha  Agemoxi CL por dia" location="MiarCuidados" veterinarian="Roberto Carlos" status="Concluída" /> */}

//                 </div>
//                 <div className='row-hm'>
//                     <h2 className='h2-hm'>Conheça nossos parceiros!</h2>
//                 </div>
//             </div>

//         </main>

//     );
// }

// export default Home;

import '../styles/Home.css';
import Title from "../components/Title/Title";
import Navbar from "../components/NavBar/NavBar";
import CardConsultation from "../components/CardConsultation/CardConsultation";
import ListLatestConsultations from "../components/ListLatestConsultations/ListLatestConsultations";
import BranchList from "../components/BranchList/BranchList"; // Importando o novo componente

function Home() {
    return (
        <main className="container-hm">
            <Navbar />
            <div className="box-hm">
                <div className='column-hm'>
                    <Title children={"Próximas Consultas"} />
                    <div className="row-consultation-hm">
                        {/* Setas simulando o carrossel da foto */}
                        <button className="carousel-arrow">‹</button>
                        
                        <div className="carousel-cards">
                            <CardConsultation namePet="Pituffinho" date="19/05/2026" time="09:30" symptoms="Coceira intensa nas costas, tosse e espirro constante" location="Clínica LevaAUqui" veterinarian="Roberto Caulos" />
                            <CardConsultation namePet="Pituffinho" date="19/05/2026" time="09:30" symptoms="Coceira intensa nas costas, tosse e espirro constante" location="Clínica LevaAUqui" veterinarian="Roberto Caulos" />
                        </div>

                        <button className="carousel-arrow">›</button>
                    </div>
                    
                    <Title children={"Histórico Veterinário"} />
                    
                    <div className="history-list-wrapper">
                        <ListLatestConsultations namePet="Pituffinho" dateConsultation="01/02/2026" symptoms="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever sin" medication="1 pastilha Agemoxi CL por dia" location="São Paulo" veterinarian="Fernado Reis" status="Concluido" />
                        
                        <ListLatestConsultations namePet="Pituffinho" dateConsultation="01/02/2026" symptoms="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever sin" medication="1 pastilha Agemoxi CL por dia" location="São Carlos" veterinarian="Fernado Reis" status="Concluido" />
                    </div>
                </div>

                {/* Coluna da direita renderizada via componente */}
                <BranchList />
            </div>
        </main>
    );
}

export default Home;