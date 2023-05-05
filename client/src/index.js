import React, { createContext } from 'react';
import ReactDOM from 'react-dom/client';
import UserStore from './store/UserStore';
import App from './App';
import UrlStore from './store/UrlStore';

export const Context = createContext(null);

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <Context.Provider value={{
    user: new UserStore(),
    urls: new UrlStore(),
  }}>
    <App />
  </Context.Provider>
);
