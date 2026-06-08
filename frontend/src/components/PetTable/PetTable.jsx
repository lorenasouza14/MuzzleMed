import { useState, useEffect } from 'react';
import './PetTable.css';
import { LuTrash, LuPencil } from 'react-icons/lu';
import { getPets, deletePet } from '../../services/routes/pet';
import Swal from 'sweetalert2';

const PetTable = () => {
    const [currentPage, setCurrentPage] = useState(1);
    const [pets, setPets] = useState([]);

    const ITEMS_PER_PAGE = 5;

    // Carrega os pets toda vez que a página atual muda (e também na montagem inicial)
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
    }, [currentPage]);

    const handleDelete = (id, name) => {
        Swal.fire({
            title: `Excluir Pet ${name}?`,
            text: "Você tem certeza que deseja excluir este pet? Esta ação não pode ser desfeita.",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: 'var(--rosa-escuro)', 
            cancelButtonColor: '#6c757d',
            confirmButtonText: 'Sim, desejo excluir!',
            cancelButtonText: 'Cancelar'
        }).then((result) => {
            if (result.isConfirmed) {
                deletePet(id)
                    .then(() => {
                        setPets((prevPets) => prevPets.filter((pet) => pet.id !== id));
                        
                        Swal.fire({
                            title: 'Excluído!',
                            text: 'O registro do pet foi removido com sucesso.',
                            icon: 'success',
                            confirmButtonColor: 'var(--azul-escuro)'
                        });
                    })
                    .catch((error) => {
                        console.error("Erro ao deletar pet:", error);
                        
                        const errorMessage = error.response?.data?.message || 
                                             error.response?.data || 
                                             "Não foi possível remover o pet no momento, pois existem consultas futuras agendadas. Por favor, cancele essas consultas antes de tentar excluir o pet.";

                        Swal.fire({
                            title: 'Não foi possível excluir',
                            text: errorMessage,
                            icon: 'error',
                            confirmButtonColor: 'var(--azul-escuro)'
                        });
                    });
            }
        });
    };

    // 🛠️ FUNÇÃO DE EDIÇÃO CORRIGIDA COM POPUP DE MANUTENÇÃO
    const handleEdit = (id) => {
        console.log(`Tentativa de editar o ID: ${id} - Funcionalidade em manutenção.`);
        
        Swal.fire({
            title: 'Em Manutenção',
            text: 'Em breve esta funcionalidade estará disponível!',
            icon: 'info',
            confirmButtonColor: 'var(--azul-escuro)',
            confirmButtonText: 'Entendido'
        });
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
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {currentData.map((pet, index) => (
                        <tr key={pet.id}>
                            <td>{startIndex + index + 1}</td> {/* Ajustado para refletir o número correto na paginação */}
                            <td>{pet.name}</td>
                            <td>{pet.specie}</td>
                            <td>{pet.breed}</td>
                            <td>{pet.dateOfBirth}</td>
                            <td>{pet.gender}</td>
                            <td className="actions">
                                <button className="btn-delete" onClick={() => handleDelete(pet.id, pet.name)} title="Excluir">
                                    <LuTrash size={18} style={{ color: "var(--rosa-escuro)" }} />
                                </button>
                                
                                <button className="btn-edit" onClick={() => handleEdit(pet.id)} title="Editar">
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