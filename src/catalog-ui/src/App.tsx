import React, { Component}  from 'react';
import { Route, Routes, useParams } from "react-router-dom";
import { BookList } from './components/books/BookList';
import './App.css';
import { BookCreate, BookDelete, BookUpdate } from './components/books/BookEdit';

const BookUpdateWrapper = () => {
  const params = useParams();
  return <BookUpdate id={params.id} />;
};

const BookDeleteWrapper = () => {
  const params = useParams();
  return <BookDelete id={params.id} />;
};

class App extends Component {
  render() {
    return (
      <Routes>
        <Route path="/" element={ <BookList/> } />
        <Route path="/createbook" element={ <BookCreate/> } />
        <Route path="/updatebook/:id" element={ <BookUpdateWrapper/> } />
        <Route path="/deletebook/:id" element={ <BookDeleteWrapper/> } />
      </Routes> 
    );
  }
}

export default App;