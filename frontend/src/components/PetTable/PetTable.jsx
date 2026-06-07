import  { useState, useEffect } from 'react';
import './PetTable.css'; 
import { LuTrash, LuPencil } from 'react-icons/lu';
import { getPets } from '../../services/routes/pet';

const PetTable = () => {
    const [currentPage, setCurrentPage] = useState(1);
    const [pets, setPets] = useState([]); 
    
    const ITEMS_PER_PAGE = 5;
    const userId = localStorage.getItem("userId");
    

useEffect(() => {
    const fetchPets = async () => {
        try {
        
            const data = await getPets(userId); 
            setPets(Array.isArray(data) ? data : []);
        } catch (error) {
            console.error("Erro ao carregar pets:", error);
        }
    };

    if (userId) { 
        fetchPets();
    }
}, [userId]);

    const handleDelete = (name) => {
        console.log(`Preparando para deletar na API o registro com Nome: ${name}`);
    };

    const handleEdit = (name) => {
        console.log(`Abrir modal de edição para o Nome: ${name}`);
    };

   
    const totalPages = Math.ceil(pets.length / ITEMS_PER_PAGE);
    const startIndex = (currentPage - 1) * ITEMS_PER_PAGE;
    const currentData = pets.slice(startIndex, startIndex + ITEMS_PER_PAGE);
    const emptyRows = ITEMS_PER_PAGE - currentData.length;

    const handlePageChange = (page) => {
        setCurrentPage(page);
    };

    return (
        <div className="table-wrapper">
            <table className="muzzle-table">
                <thead>
                    
                    <tr>
                        
                        <th>N°</th>
                        <th>Nome</th>
                        <th>Espécie</th>
                        <th>Raça</th>
                        <th>Data de Nascimento</th>
                        <th>Gênero</th>
                        
                    </tr>
                </thead>
                <tbody>
                    {currentData.map((pet, index) => (
                        <tr key={pet.id}>
                            <td>{index + 1}</td>
                            <td>{pet.name}</td>
                            <td>{pet.specie}</td>
                            <td>{pet.breed}</td>
                            <td>{pet.dateOfBirth}</td>
                            <td>{pet.gender}</td>
                            <td className="actions">
                                <button className="btn-delete" onClick={() => handleDelete(pet.name)} title="Excluir">
                                    <LuTrash size={18} style={{ color: "var(--rosa-escuro)" }} />
                                </button>
                                <button className="btn-edit" onClick={() => handleEdit(pet.name)} title="Editar">
                                    <LuPencil size={18} style={{ color: "var(--azul-escuro)" }} />
                                </button>
                            </td>
                        </tr>
                    ))} 
                    {emptyRows > 0 && Array.from({ length: emptyRows }).map((_, index) => (
                        <tr key={`empty-${index}`} className="empty-row">
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    ))}
                </tbody>
            </table>

            {totalPages > 1 && (
                <div className="pagination">
                    {Array.from({ length: totalPages }).map((_, index) => {
                        const pageNumber = index + 1;
                        return (
                            <span
                                key={pageNumber}
                                className={`page-number ${currentPage === pageNumber ? 'active' : ''}`}
                                onClick={() => handlePageChange(pageNumber)}
                            >
                                {pageNumber}
                            </span>
                        );
                    })}
                </div>
            )}
        </div>
    );
};

export default PetTable;