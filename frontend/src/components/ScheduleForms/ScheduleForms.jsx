import { useState } from "react";
import FormsInput from "../FormsInput/FormsInput";
import ButtonSaveCancel from "../ButtonSaveCancel/ButtonSaveCancel";
import DropdownButton from "../DropdownButton/DropdownButton";
import TimeSlotSelector from "../TimeSlotSelector/TimeSlotSelector"; 
import "../PetForms/PetForms.css";

function ScheduleForms({ onSave, onCancel }) {

    const [name, setName] = useState("");
    const [dateSchedule, setDateSchedule] = useState("");
    const [timeSchedule, setTimeSchedule] = useState(""); // 2. Trocou gender por timeSchedule

    const listaClinicas = [
        { id: "1", name: "Clínica LevaAUqui - Centro" },
        { id: "2", name: "Clínica LevaAUqui - Zona Sul" }
    ];

    const listaVeterinarios = [
        { id: "10", name: "Dr. Roberto Caulos" },
        { id: "11", name: "Dra. Fernanda Reis" }
    ];

    const handleClinicaSelecionada = (id) => {
        console.log("ID da clínica escolhida:", id);
    };

    const handleVeterinarioSelecionado = (id) => {
        console.log("ID do veterinário escolhido:", id);
    };

    const getTomorrowDateString = () => {
        const tomorrow = new Date();
        tomorrow.setDate(tomorrow.getDate() + 1); // Soma 1 dia à data atual
        
        const year = tomorrow.getFullYear();
        // O mês começa em 0, então somamos 1. O padStart garante que tenha 2 dígitos (ex: 05)
        const month = String(tomorrow.getMonth() + 1).padStart(2, "0");
        const day = String(tomorrow.getDate()).padStart(2, "0");
        
        return `${year}-${month}-${day}`;
    };

    return (
        <main className="container">

            <FormsInput
                label="Nome"
                type="text"
                name="name"
                placeholder="Nome do pet"
                value={name}
                onChange={(e) => setName(e.target.value)}
            />

            <div className="pet-row">
                <DropdownButton
                    label="Escolha a Clínica:"
                    options={listaClinicas}
                    defaultOptionText="-- Selecione uma unidade --"
                    onSelectData={handleClinicaSelecionada}
                />

                <DropdownButton
                    label="Escolha o Veterinário:"
                    options={listaVeterinarios}
                    defaultOptionText="-- Selecione um profissional --"
                    onSelectData={handleVeterinarioSelecionado}
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
                        setTimeSchedule(""); // Reseta o horário se mudar a data
                    
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

            <div style={{ display: "flex", justifyContent: "center", alignItems: "center" }}>
                <div style={{ width: "50%", marginTop: "50px" }} >
                    <ButtonSaveCancel
                        onSave={() => onSave({ name, dateSchedule, timeSchedule })}
                        onCancel={onCancel}
                    />
                </div>
            </div>
        </main>
    )
};

export default ScheduleForms;