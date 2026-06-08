import { useState } from "react";
import FormsInput from "../FormsInput/FormsInput";
import ButtonSaveCancel from "../ButtonSaveCancel/ButtonSaveCancel";
import ToggleInput from "../ToggleInput/ToggleInput";
import "./PetForms.css";
import {createPet} from "../../services/routes/pet";

function PetForms({ onSave, onCancel }) {

    const [name, setName] = useState("");
    const [specie, setSpecie] = useState("Cachorro");
    const [breed, setBreed] = useState("");
    const [dateOfBirth, setDateOfBirth] = useState("");
    const [gender, setGender] = useState("Macho");


    const handleSave = async () => {
        try {
           
        const newPet = {
            name,
            specie,
            breed,
            dateOfBirth,
            gender,
            descriptionSymtoms: "Nenhum sintoma descrito", 
           
        };
            console.log("JSON enviado para a API:", JSON.stringify(newPet));
            await createPet(newPet);
            onSave();

            if (onSave) onSave();

        } catch (error) {
            console.error("Erro ao salvar pet:", error);
        }
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

                <ToggleInput
                    label="Espécie"
                    options={[
                        { label: "Dog", value: "Dog" },
                        { label: "Cat", value: "Cat" }
                    ]}
                    value={specie}
                    onChange={setSpecie}
                />

                <FormsInput
                    label="Raça"
                    type="text"
                    name="breed"
                    placeholder="Pastor Alemão"
                    value={breed}
                    onChange={(e) => setBreed(e.target.value)}
                />
            </div>

            <div className="pet-row" >

                <FormsInput
                    label="Data de Nascimento"
                    type="date"
                    name="dateOfBirth"
                    placeholder=""
                    value={dateOfBirth}
                    onChange={(e) => setDateOfBirth(e.target.value)}
                />

                <ToggleInput
                    label="Gênero"
                    options={[
                        { label: "Male", value: "Male" },
                        { label: "Female", value: "Female" }
                    ]}
                    value={gender}
                    onChange={setGender}
                />
            </div>
            <div style={{ display: "flex", justifyContent: "center", alignItems: "center" }}>
                <div style={{ width: "50%", marginTop: "50px" }} >
                    <ButtonSaveCancel onSave={handleSave} onCancel={onCancel} />
                </div>
            </div>
        </main>
    )
};

export default PetForms;