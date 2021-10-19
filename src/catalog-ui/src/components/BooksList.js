import React, { Component } from 'react';
import { Link } from "react-router-dom";
import Select from 'react-select';
import { List } from './List';
import { Books } from './Books';
import ApiBook from '../services/apiBooks';

export class BooksList extends Component {
  static displayName = BooksList.name;

  constructor() {
    super();
    this.state = { catalog: [], loading: true, criteria: null, search: null };
    this.options = [
      { value: 'Name', label: 'Book Name:' },
      { value: 'Author', label: 'Author:' },
      { value: 'Category', label: 'Category:' }
    ];
  }

  onCriteriaChange = (selectedOption) => {
    this.setState({ criteria: selectedOption.value });
  }

  onSearchChange = (event) => {
    this.setState({ search: event.target.value });
  }

  onSearchSubmit = () => {
    const criteria = this.state.criteria;
    const search = this.state.search;
    if (criteria && search) {
      this.setState({ loading: true });
      this.populateListByCriteria(criteria, search);
    }
    
  }

  componentDidMount() {
    this.populateList();
  }

  render() {
    let contents = this.state.loading
      ? <div className='alert alert-light'>Loading data...</div>
      : this.state.error 
         ? <div className='alert alert-danger mt-3'>An error happened with Catalog Service: <strong>{this.state.error}</strong></div>
         : <Books books={this.state.catalog} />;

    return (      
      <List>
        <h1 id="tabelLabel" >Book Catalog</h1>
        <div className="row">
          <div className="col col-md-8">
            <div className="input-group">
              <Select 
                className="w-25"
                options={this.options}
                autoFocus={true}
                placeholder='Search by...'
                onChange={this.onCriteriaChange}
              />
              <input
                type="text"
                className="form-control"
                onChange={this.onSearchChange}
              />
              <button
                className="btn btn-outline-secondary"
                type="button"
                onClick={this.onSearchSubmit}>
                Search
              </button>
            </div>
          </div>
          <div className="col col-md-2">
           <Link to="/createbook">
              <button
                className="btn btn-primary"
                type="button">
                New Book
              </button>
            </Link>
          </div>
        </div>
        {contents}
      </List>
    );
  }

  async populateList() {
    await ApiBook.getAll()
      .then(response => this.setState({ catalog: response, loading: false, criteria: null, search: null }))
      .catch(err => { 
        console.log(err);
        this.setState( { error: err.message, loading: false });
    });
  }

  async populateListByCriteria(criteria, search) {
    await ApiBook.getByCriteria(criteria, search)
      .then(response => this.setState({ catalog: response, loading: false, criteria: criteria, search: search, error: null }))
      .catch(err => { 
        console.log(err);
        const status = err.response.status;
        const message = status === 404 ? `Not found books by ${criteria}` : err.message;
        this.setState({ error: message, loading: false });
    }); 
  }
}
