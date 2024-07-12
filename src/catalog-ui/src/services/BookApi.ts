import { Book } from '../types/Book';
import Api from './Api';

class BookApi extends Api {
    async getAll(): Promise<Book[]> {
        let books: Book[] = [];
        await this.api.get('Books')
            .then(response => books = response.data);
        return books;
    }  

    async getByCriteria(criteria: string, search: string): Promise<Book[]> {
        let books: Book[] = [];
        await this.api.get(`Books/${criteria}/${search}`)
            .then(response => books = response.data);
        return books;
    }

    async getById(id: string): Promise<Book> {
        // eslint-disable-next-line @typescript-eslint/consistent-type-assertions
        let book: Book = <Book>{};
        await this.api.get(`Books/${id}`)
          .then(response => book = response.data);
        return book;
    }

    async create(book: Book): Promise<Book> {
        return await this.api.post('Books/', book);
    }
    
    async update(book: Book) {
        return await this.api.put('Books/', book);
    }
    
    async delete(id: string) {
        return await this.api.delete(`Books/${id}`);
    }
}

// eslint-disable-next-line import/no-anonymous-default-export
export default new BookApi();
