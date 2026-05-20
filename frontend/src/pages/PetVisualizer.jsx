import React, { useState } from "react";
import Navbar from "../components/NavBar/NavBar";
import Title from "../components/Title/Title";
import Modal from "../components/Modal/Modal";
import PetForms from "../components/PetForms/PetForms";
import PetTable from "../components/PetTable/PetTable";

function PetVisualizer() {

    const [isModalOpen, setModalOpen] = useState(false);

    return (

        <main className="container">

            <Navbar />

            <div className="pet-container" style={{ padding: "20px 70px" }}>
                <Title title="Visualizador de Pets" botao="Adicionar" onButtonClick={() => {
                    setModalOpen(true);
                }} showButton={true} />

                <div>
                    <PetTable />
                </div>

            </div>

            <div>
            <Modal
                isOpen={isModalOpen}
                onClose={() => setModalOpen(false)}>
            <PetForms onSave={() => setModalOpen(false)} onCancel={() => setModalOpen(false)} />
            </Modal>
            </div>
        </main>
    );
}

export default PetVisualizer;