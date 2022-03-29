import React, { Component } from 'react';
import { Route, Routes } from "react-router-dom";
import { BooksList } from './components/BooksList';
import { BookCreate, BookUpdate, BookDelete } from './components/BookEdit';

import './App.css';

class App extends Component {
  render() {
    return (
      <Routes>
        <Route path="/createbook" element={ <BookCreate/> } />
        <Route path="/updatebook/:id" element={ <BookUpdate/>} />
        <Route path="/deletebook/:id" element={ <BookDelete/>} />
        <Route path="/" element={ <BooksList/> } />
      </Routes>
    );
  }
}

export default App;
