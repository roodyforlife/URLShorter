import { observer } from 'mobx-react-lite';
import React, { useContext } from 'react'
import { Route, Routes } from 'react-router-dom';
import { Context } from '..';
import { authRoutes, publicRoutes } from '../routes';
import Content from './Content';
import NavBar from './UI/NavBar/NavBar';

const AppRouter = observer(() => {
    const {user} = useContext(Context);
  return (
    <div>
    <NavBar></NavBar>
    <Content>
        {user.isAuth &&
                <Routes>
                    {authRoutes.map(({path, component, roles}) => 
                        roles.includes(user.user.roles) && <Route path={path} element={component} key={path}/>
                    )}
                </Routes>}
            <Routes>
                {publicRoutes.map(({path, component}) => 
                    <Route path={path} element={component} key={path}></Route>
                )}
            </Routes>
        </Content>
    </div>
  )
});

export default AppRouter;
