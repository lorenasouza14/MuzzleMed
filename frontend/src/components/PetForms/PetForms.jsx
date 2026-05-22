import { useState } from "react";
import FormsInput from "../FormsInput/FormsInput";
import ButtonSaveCancel from "../ButtonSaveCancel/ButtonSaveCancel";
import ToggleInput from "../ToggleInput/ToggleInput";
import "./PetForms.css";

function PetForms({ onSave, onCancel }) {

    const [name, setName] = useState("");
    const [species, setSpecies] = useState("Cachorro");
    const [breed, setBreed] = useState("");
    const [dateOfBirth, setDateOfBirth] = useState("");
    const [gender, setGender] = useState("Macho");

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
                        { label: "Cachorro", value: "Cachorro" },
                        { label: "Gato", value: "Gato" }
                    ]}
                    value={species}
                    onChange={setSpecies}
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
                        { label: "Macho", value: "Macho" },
                        { label: "Fêmea", value: "Fêmea" }
                    ]}
                    value={gender}
                    onChange={setGender}
                />
            </div>
            <div style={{ display: "flex", justifyContent: "center", alignItems: "center" }}>
                <div style={{ width: "50%", marginTop: "50px" }} >
                    <ButtonSaveCancel onSave={onSave} onCancel={onCancel} />
                </div>
            </div>
        </main>
    )
};

export default PetForms;