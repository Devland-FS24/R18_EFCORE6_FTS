import { Button, Table } from "reactstrap";

const MovieTable = ({ data, setEdit, showModal, setShowModal }) => {

    const sendData = (movie) => {
        setEdit(movie)
        setShowModal(!showModal)
    }

    return (

        <Table striped responsive>
            <thead>

                <tr>
                    <th>Title</th>
                    <th>Genre</th>
                       
                    <th></th>
                </tr>
            </thead>
            <tbody>
                {

                    (data.length < 1) ? (
                        <tr>
                            <td colSpan="4">No records</td>
                        </tr>
                    ) : (
                        data.map((item) => (

                            <tr key={item.movieId}>
                                <td>{item.title}</td>                        
                                <td>{item.genre}</td>                     
                                <td>
                                    <Button color="primary" size="sm" className="me-2"
                                        onClick={() => sendData(item)}
                                    >View details</Button>
                                </td>
                            </tr>
                        ))
                    )
                }
            </tbody>
        </Table>
    )
}

export default MovieTable;