import jwt_decode from "jwt-decode";
import { observer } from "mobx-react-lite";
import { useContext, useEffect, useState } from "react";
import { BrowserRouter } from "react-router-dom";
import { Context } from ".";
import AppRouter from "./components/AppRouter";
import Spinner from "./components/UI/Spinner/Spinner";
import { check } from "./http/userApi";
import './styles/App.css';

const App = observer(() => {
  const {user} = useContext(Context);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    check().then(data => {
      user.setUser(jwt_decode(localStorage.getItem('token')));
      user.setIsAuth(true);
    }).finally(() => setLoading(false));
  }, [user])

  if (loading){
    return <Spinner />
  }

  return (
    <div className="App">
      <BrowserRouter>
        <AppRouter />
      </BrowserRouter>
    </div>
  );
});

export default App;
