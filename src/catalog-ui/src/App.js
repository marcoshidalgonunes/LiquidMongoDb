import React, { Component } from 'react';
import { Route, Routes, useParams } from "react-router-dom";
import { BooksList } from './components/BooksList';
import { BookCreate, BookUpdate, BookDelete } from './components/BookEdit';

import './App.css';

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
        <Route path="/createbook" element={ <BookCreate/> } />
        <Route path="/updatebook/:id" element={ <BookUpdateWrapper/> } />
        <Route path="/deletebook/:id" element={ <BookDeleteWrapper/> } />
        <Route path="/" element={ <BooksList/> } />
      </Routes>
    );
  }
}

export default App;
