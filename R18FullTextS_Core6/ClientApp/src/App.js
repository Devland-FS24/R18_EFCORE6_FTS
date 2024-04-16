import { useEffect, useState } from "react"
import { Col, Container, Row, Card, CardHeader, CardBody, Button, Form, FormGroup, Input, InputGroup, Label } from "reactstrap"
import MovieModal from "./components/MovieModal";
import MovieTable from "./components/MovieTable";


const App = () => {

    const [movies, setMovies] = useState([])
    const [showModal, setShowModal] = useState(false)
    const [edit, setEdit] = useState(null)



    const showMovies = async (value) => {        
        var searchterm = "\\" + '"' + value  + '*"\\';
        console.log(searchterm);
        const response = await fetch("api/movie/FindMoviesFullTextSearch/" + searchterm)
     
        if (response.ok) {
            const data = await response.json();
            setMovies(data)
        } else {
            console.log("error fetching data");
        }

    }

    useEffect(() => {     
    }, [])



    return (
        <Container>
            <Row className="mt-5">
                <Col sm="12">
                    <Card>
                        <CardHeader>
                            <h5>Movies</h5>
                            <Input icon='search'
                                placeholder='Search...'   
                                onChange={(e) => showMovies(e.target.value)}
                            />
                        </CardHeader>
                        <CardBody>
                            <MovieTable data={movies}
                                setEdit={setEdit}
                                showModal={showModal}
                                setShowModal={setShowModal}
                            />
                        </CardBody>
                    </Card>
                </Col>
            </Row>
            <MovieModal
                showModal={showModal}
                setShowModal={setShowModal}
                edit={edit}
                setEdit={setEdit}
            />
        </Container>
    )
}

export default App;