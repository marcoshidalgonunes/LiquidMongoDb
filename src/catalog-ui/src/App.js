import React, { Component } from 'react';
import { Route, Switch } from "react-router-dom";
import { BooksList } from './components/BooksList';
import { BookCreate, BookUpdate, BookDelete } from './components/BookEdit';

import './App.css';

class App extends Component {
  render() {
    return (
      <Switch>
        <Route path="/createbook" component={BookCreate} />
        <Route path="/updatebook/:id" component={BookUpdate} />
        <Route path="/deletebook/:id" component={BookDelete} />
        <Route path="/" component={BooksList} />
      </Switch>
    );
  }
}

export default App;
