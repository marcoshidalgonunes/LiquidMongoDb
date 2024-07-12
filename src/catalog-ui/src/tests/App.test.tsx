import React from 'react';
import { render, screen } from '@testing-library/react';
import App from '../App';
import { BrowserRouter } from 'react-router-dom';

test('renders app main page', () => {
  render(<BrowserRouter>
    <App />
  </BrowserRouter>);
  const headerElement = screen.getByText(/Book Catalog/i);
  expect(headerElement).toBeInTheDocument();
});
