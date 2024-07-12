/* eslint-disable react/no-direct-mutation-state */
import React, { Component } from 'react';
import { Link, Navigate } from "react-router-dom";
import BookApi from '../../services/BookApi';
import { EditProps } from '../../types/EditProps';
import { Book } from '../../types/Book';

type BookEditState = {
  loading: boolean;
  id?: string; 
  name: string| undefined;
  author: string| undefined; 
  category: string| undefined; 
  price: number| undefined;
  error: string| null;
  redirect: string| null;
}

abstract class BookEdit extends Component<EditProps> {
    action: string = '';
    state!: BookEditState;

    onAuthorChange = (event: React.ChangeEvent<HTMLInputElement>) => {
      this.setState({ author: event.target.value });
    }

    onCategoryChange = (event: React.ChangeEvent<HTMLInputElement>) => {
      this.setState({ category: event.target.value });
    }

    onPriceChange = (event: React.ChangeEvent<HTMLInputElement>) => {
      this.setState({ price: event.target.value });
    }

    onNameChange = (event: React.ChangeEvent<HTMLInputElement>) => {
      this.setState({ name: event.target.value });
    }

    onCancel = () => {
      this.setState({ redirect: '/'});
    }

    onSubmit = () => {}
  
    componentDidMount() {
      this.populateBook();
    }
    
    render() {
      let content = this.state.loading
        ? <div className='alert alert-light'>Loading data...</div>
        : this.state.error 
           ? <div className='alert alert-danger mt-3 mx-5'>An error happened with Catalog Service: <strong>{this.state.error}</strong><hr/><Link to='/'>Return</Link></div>
           : this.state.redirect 
             ? <Navigate to={this.state.redirect} />
             : this.createForm();
      return (
        <div>
          {content}
        </div>
      )
    }

    getBook(): Book {
      return {
        Id: undefined,
        Name: this.state.name,
        Author: this.state.author,
        Category: this.state.category,
        Price: this.state.price
      }
    }

    async populateBook() {
      const id = this.state.id;
      if (id) {
        await BookApi.getById(id)
          .then(response => this.setState({
            loading: false,
            id: response.Id,
            name: response.Name,
            author: response.Author,
            category: response.Category,
            price: response.Price
          }))
          .catch(err => { 
            console.log(err);
            this.setState( { loading: false, error: err.message });
          });
      }
      else {
        this.setState({ loading: false })
      }
    }

    createForm() {
      return (
        <div className="container h-100">
          <div className="row h-100 justify-content-center align-items-center">
            <div className="col-10 col-md-8 col-lg-6">
              <h1>{this.action} Book</h1>
              <div className="form-group mt-2">
                <label htmlFor="name">Name</label>
                <input
                  type="text"
                  className="form-control"
                  id="name"
                  required
                  value={this.state.name}
                  onChange={this.onNameChange}
                  name="title"
                />
              </div>
              <div className="form-group mt-2">
                <label htmlFor="author">Author</label>
                <input
                  type="text"
                  className="form-control"
                  id="author"
                  required
                  value={this.state.author}
                  onChange={this.onAuthorChange}
                  name="author"
                />
              </div>
              <div className="form-group mt-2">
                <label htmlFor="category">Category</label>
                <input
                  type="text"
                  className="form-control"
                  id="category"
                  required
                  value={this.state.category}
                  onChange={this.onCategoryChange}
                  name="category"
                />
              </div>
              <div className="form-group mt-2">
                <label htmlFor="price">Price</label>
                <input
                  type="number"
                  min="0.0"
                  step="0.01"
                  className="form-control"
                  id="price"
                  required
                  value={this.state.price}
                  onChange={this.onPriceChange}
                  name="price"
                />
              </div>
              <div className="d-flex justify-content-center">
                <button onClick={this.onSubmit} className="btn btn-primary mt-3 mx-1">
                  Submit
                </button>
                <button onClick={this.onCancel} className="btn btn-outline-secondary mt-3 mx-1">
                  Cancel
                </button>
              </div>
            </div>
          </div>
        </div>
      )  
    }
}

export class BookCreate extends BookEdit {
  constructor(props: EditProps) {
    super(props);
    this.state = { 
      loading: true,
      id: props.id, 
      name: undefined,
      author: undefined,
      category: undefined,
      price: undefined, 
      error: null,
      redirect: null
    };    
    this.onSubmit = this.onCreateSubmit;
    this.action = 'New';
  }

  onCreateSubmit = () => {
    this.createBook();
  }

  async populateBook() {
    this.setState({ loading: false });
  }

  async createBook() {
    const book = this.getBook();
    await BookApi.create(book)
      .then(() => this.setState({ redirect: '/'}))
      .catch(err => { 
        console.log(err);
        this.setState( { error: err.message });
    });
  }
}

export class BookUpdate extends BookEdit {
  constructor(props: EditProps) {
    super(props);
    this.state = { 
      loading: true,
      id: props.id, 
      name: undefined,
      author: undefined,
      category: undefined,
      price: undefined, 
      error: null,
      redirect: null
    };    
    this.onSubmit = this.onUpdateSubmit;
    this.action = 'Update';
  }

  onUpdateSubmit = () => {
    this.updateBook();
  }

  async updateBook() {
    const book = this.getBook();
    book.Id = this.state.id;
    await BookApi.update(book)
      .then(() => this.setState({ redirect: '/'}))
      .catch(err => { 
        console.log(err);
        const status = err.response.status;
        const message = status === 404 ? 'Book not found' : err.message;
        this.setState({ error: message, loading: false });
    }); 
  }
}

export class BookDelete extends BookEdit {
  static displayName = BookDelete.name;

  constructor(props: EditProps) {
    super(props);
    this.state = { 
      loading: true,
      id: props.id, 
      name: undefined,
      author: undefined,
      category: undefined,
      price: undefined, 
      error: null,
      redirect: null
    };     
    this.action = 'Delete';
  }

  onDeleteSubmit = () => {
    this.deleteBook();
  }

  async deleteBook() {
    const id = this.state.id || '';
    await BookApi.delete(id)
      .then(() => this.setState({ redirect: '/'}))
	    .catch(err => { 
        console.log(err);
        this.setState( { loading: false, error: err.message });
	  });
  }
  
  createForm() {
    return (
      <div className="container h-100">
        <div className="row h-100 justify-content-center align-items-center">
          <div className="col-10 col-md-8 col-lg-6">
            <h1>Delete Book</h1>
            <div className='alert alert-warning'>
			        Are you sure to delete the book <strong>{this.state.name}</strong> from <strong>{this.state.author}</strong>?
			      </div>
            <div className="d-flex justify-content-center">
              <button onClick={this.onCancel} className="btn btn-outline-secondary mt-3 mx-1">
                Cancel
              </button>
              <button onClick={this.onDeleteSubmit} className="btn btn-warning mt-3 mx-1">
                Delete
              </button>
            </div>
          </div>
        </div>
      </div>
    )  
  } 
}