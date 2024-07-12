import React, { Component } from 'react';
import { List } from '../List';
import { Link } from "react-router-dom";
import Select, { SingleValue } from 'react-select';
import BookApi from '../../services/BookApi';
import { Book } from '../../types/Book';
import { SelectedItem } from '../../types/SelectedItem';
import { Books } from './BookTable';

export class BookList extends Component {
  options: SelectedItem[];
  state: { catalog: Book[]; loading: boolean; criteria: string| null; search: string| null; error: string| null; }

  constructor(props: {} | Readonly<{}>) {
    super(props);
    this.state = { catalog: [], loading: true, criteria: null, search: null, error: null };
    this.options = [
      { label: 'Book Name:', value: 'Name' },
      { label: 'Author:', value: 'Author', },
      { label: 'Category:', value: 'Category' }
    ];
  }

  onCriteriaChange = (newValue: SingleValue<SelectedItem>) => {
    if (newValue) {
      this.setState({ criteria: newValue.value });
    }    
  }
  
  onSearchChange = (event: React.ChangeEvent<HTMLInputElement>) => {
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

  async populateList() {
    await BookApi.getAll()
      .then((data) => { 
        this.setState({ catalog: data, loading: false, criteria: null, search: null, error: null })
      })
      .catch(err => { 
        console.log(err);
        this.setState( { catalog: [], error: err.message, loading: false });
    });
  }

  async populateListByCriteria(criteria: string, search: string) {
    await BookApi.getByCriteria(criteria, search)
      .then((data) => { 
        this.setState({ catalog: data, loading: false, criteria: criteria, search: search, error: null })
      })
      .catch(err => { 
        console.log(err);
        const status = err.response.status;
        const message = status === 404 ? `Not found books with ${criteria} containing '${search}'` : err.message;
        this.setState({ catalog: [], error: message, loading: false });
    }); 
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
                onClick={this.onSearchSubmit}
                >
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
        )
    }
}