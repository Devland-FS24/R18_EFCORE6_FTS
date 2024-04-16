import { useEffect, useState } from 'react'
import { Modal, ModalBody, ModalHeader, Form, FormGroup, Input, Label, ModalFooter, Button } from "reactstrap"

const modelMovie = {
    movieid: 0,
    title: "",
    genre: "",
    castByMovie: ""
}

const MovieModal = ({ showModal, setShowModal, edit, setEdit }) => {

    const [movie, setMovie] = useState(modelMovie);

    useEffect(() => {
        if (edit != null) {
            
            setMovie(edit)
        } else {
          
            setMovie(modelMovie)
        }
    }, [edit])


    const closeModal = () => {

        setShowModal(!showModal)
        setEdit(null)
    }

    return (
         
        <Modal isOpen={showModal}>
            <ModalHeader>
                {
                    "Movie Details"
                }
            </ModalHeader>
            <ModalBody>
                <Form>
                    <div>
                        <p>Movie Id: {movie.movieId} </p>
                        <p>Title: {movie.title} </p>                    
                        <p>Genre: {movie.genre} </p>
                        <p>Main Cast</p>
                        <p>Genre: {movie.castByMovie} </p>
                    </div>              
          
                </Form>
            </ModalBody>
            <ModalFooter>             
                <Button color="danger" size="sm" onClick={closeModal}>Close</Button>
            </ModalFooter>
        </Modal>
    )

}

export default MovieModal;