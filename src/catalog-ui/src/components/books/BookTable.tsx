import React, { Component } from 'react';
import { Link } from "react-router-dom";
import { Book } from '../../types/Book';
import { BookListProps } from '../../types/BookListProps';

export class Books extends Component<BookListProps> { 
    static displayName: string = "Books";
    books: Book[];

    constructor(props: BookListProps) {
        super(props);
        this.books = props.books;
    }

    render() {      
        return (
          <table className='table table-striped' aria-labelledby="tabelLabel">
          <thead>
            <tr>
              <th>Name</th>
              <th>Author</th>
              <th>Category</th>
              <th>Price</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            {this.books && this.books.length > 0 && this.books.map(book =>
              <tr key={book.Id}>
                <td>
                  <Link to={{ pathname: `/updatebook/${book.Id}`}}>
                  {book.Name}
                  </Link>
                </td>
                <td>{book.Author}</td>
                <td>{book.Category}</td>
                <td>{book.Price}</td>
                <td>
                  <Link to={{ pathname: `/deletebook/${book.Id}`}}>
                    <button
                      className="btn btn-outline-warning py-0"
                      type="button">
                      Delete
                    </button>
                  </Link>
                </td>
              </tr>
            )}
          </tbody>
        </table>
      );
    }    
}