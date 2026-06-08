import { useState, useEffect } from "react";
import FormsInput from "../FormsInput/FormsInput";
import ButtonSaveCancel from "../ButtonSaveCancel/ButtonSaveCancel";
import DropdownButton from "../DropdownButton/DropdownButton";
import TimeSlotSelector from "../TimeSlotSelector/TimeSlotSelector"; 
import TextareaButton from "../TextareaButton/TextareaButton";
import "../PetForms/PetForms.css";
import { getClinics } from "../../services/routes/clinic";
import { getVetById } from "../../services/routes/veterinary";
import { getPets } from "../../services/routes/pet";
import { createSchedules } from "../../services/routes/schedule"; 

function ScheduleForms({ onSave, onCancel }) {
    const [clinics, setClinics] = useState([]);
    const [vets, setVets] = useState([]);
    const [pets, setPets] = useState([]);

    const [selectedClinicId, setSelectedClinicId] = useState(null);
    const [selectedPetId, setSelectedPetId] = useState(null); 
    const [selectedVetId, setSelectedVetId] = useState(null);
    const [dateSchedule, setDateSchedule] = useState("");
    const [timeSchedule, setTimeSchedule] = useState("");
    const [description, setDescription] = useState(""); 

    useEffect(() => {
        const fetchClinics = async () => {
            const data = await getClinics();
            setClinics(Array.isArray(data) ? data : []);
        };
        fetchClinics();
    }, []);

    useEffect(() => {
        if (selectedClinicId) {
            const fetchVetsByClinic = async () => {
                try {
                    const data = await getVetById(selectedClinicId);
                    setVets(Array.isArray(data) ? data : []);
                } catch (error) {
                    console.error("Erro ao carregar veterinários:", error);
                }
            };
            fetchVetsByClinic();
        }
    }, [selectedClinicId]);

    useEffect(() => {
        const fetchPets = async () => {
            try {
                const data = await getPets();
                setPets(Array.isArray(data) ? data : []);
            } catch (error) {
                console.error("Erro ao carregar pets:", error);
            }
        };
        fetchPets();
    }, []);



    // const handleVeterinarioSelecionado = (id) => {
    //     console.log("ID do veterinário escolhido:", id);
    // };

    const getTomorrowDateString = () => {
        const tomorrow = new Date();
        tomorrow.setDate(tomorrow.getDate() + 1); 
        const year = tomorrow.getFullYear();
        const month = String(tomorrow.getMonth() + 1).padStart(2, "0");
        const day = String(tomorrow.getDate()).padStart(2, "0");
        return `${year}-${month}-${day}`;
    };


    const handleSaveAppointment = async () => {
        if (!selectedPetId || !selectedClinicId || !selectedVetId || !dateSchedule || !timeSchedule) {
            alert("Por favor, preencha todos os campos obrigatórios.");
            return;
        }

        const newAppointment = {
            petId: selectedPetId,
            clinicId: selectedClinicId,
            vetId: selectedVetId,
            date: dateSchedule,
            time: timeSchedule, 
            symptomDescription: description 
        };

        try {
            await createSchedules(newAppointment);
            alert("Consulta agendada com sucesso!");
            
            onSave(); 
            window.location.reload();
        } catch (error) {
            console.error("Erro completo:", error);
            
          
            const mensagemBackend = error.response?.data?.message 
                            || error.response?.data 
                            || "Erro ao agendar consulta. Tente novamente.";
            
            alert(mensagemBackend);
        }
    };

    return (
        <main className="container">
            <DropdownButton
                label="Selecione o seu Pet:"
                options={[...pets.map(pet => ({ id: pet.id, name: pet.name }))]}
                defaultOptionText="-- Selecione um pet --"
                onSelectData={(id) => setSelectedPetId(id)} 
            />

            <div className="pet-row">
                <DropdownButton
                    label="Escolha a Clínica:"
                    options={clinics.map(clinic => ({ id: clinic.id, name: clinic.name }))}
                    defaultOptionText="-- Selecione uma unidade --"
                    onSelectData={(id) => setSelectedClinicId(id)}
                />
                
                <DropdownButton
                    label="Escolha o Veterinário:"
                    options={vets.map(vet => ({ id: vet.id, name: vet.fullName }))} 
                    defaultOptionText="-- Selecione um profissional --"
                    onSelectData={(id) => setSelectedVetId(id)} 
                />
            </div>

            <div className="pet-row">
                <FormsInput
                    label="Selecione a data"
                    type="date"
                    name="dateSchedule"
                    value={dateSchedule}
                    min={getTomorrowDateString()}
                    onChange={(e) => {
                        setDateSchedule(e.target.value);
                        setTimeSchedule(""); 
                    }}
                />

                <TimeSlotSelector
                    label="Horário da Consulta"
                    selectedTime={timeSchedule}
                    onTimeChange={setTimeSchedule}
                    isDateSelected={!!dateSchedule}
                    dateSchedule={dateSchedule}
                />
            </div>
            
            <TextareaButton
                label="Descrição dos Sintomas"
                name="descriptionSymtoms"
                placeholder="Descreva os sintomas do seu pet..."
                value={description}
                onChange={(e) => setDescription(e.target.value)} 
            />

            <div style={{ display: "flex", justifyContent: "center", alignItems: "center" }}>
                <div style={{ width: "50%", marginTop: "50px" }} >
                    <ButtonSaveCancel
                        onSave={handleSaveAppointment} 
                        onCancel={onCancel}
                    />
                </div>
            </div>
        </main>
    )
};

export default ScheduleForms;