import { observer } from 'mobx-react-lite';
import React, { useContext } from 'react'
import { NavLink } from 'react-router-dom';
import { Context } from '../../..';
import { LOGIN_ROUTE, REGIST_ROUTE, MAIN_ROUTE} from '../../../utils/consts';
import cl from './NavBar.module.css';

const NavBar = observer(() => {
    const {user} = useContext(Context);

    const logout = () => {
        localStorage.removeItem('token');
        user.setIsAuth(false);
        user.setUser({});
    }

  return (
    <header>
        <div className={cl.header__content}>
            <div className={cl.links}>
            <NavLink to={MAIN_ROUTE}>Home</NavLink>
            {!user.isAuth ?
                <div><NavLink to={LOGIN_ROUTE}>Login</NavLink>
                <NavLink to={REGIST_ROUTE}>Registration</NavLink></div>
            :
            <nav onClick={logout}>Logout</nav>
            
        }
            </div>
            {user.isAuth && <nav>You are logged in as {user.user.name}</nav>}
        </div>
    </header>
  )
});

export default NavBar;