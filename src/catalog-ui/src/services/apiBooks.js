import Api from './api';

class ApiBooks extends Api {
    async getAll() {
        return await this.apiClient.get('Books');
    }

    async getByCriteria(criteria, search) {
        return await this.apiClient.get(`Books/${criteria},${search}`);
    }

    async getById(id) {
        return await this.apiClient.get(`Books/${id}`);
    }

    async create(book) {
        return await this.apiClient.post('Books/', book);
    }
    
    async delete(id) {
        return await this.apiClient.delete(`Books/${id}`);
    }
    
    async update(book) {
        return await this.apiClient.put('Books/', book);
    }
}

export default new ApiBooks();