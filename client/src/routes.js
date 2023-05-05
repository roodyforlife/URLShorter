import Error from "./pages/Error";
import Login from "./pages/Login";
import Main from "./pages/Main";
import Redirector from "./pages/Redirector";
import Registration from "./pages/Registration";
import { ERROR_ROUTE, INFO_ROUTE, LOGIN_ROUTE, MAIN_ROUTE, REGIST_ROUTE, URL_INFO } from "./utils/consts";

export const authRoutes = [
]

export const publicRoutes = [
    {path: LOGIN_ROUTE, component: <Login /> },
    {path: REGIST_ROUTE, component: <Registration />},
    {path: MAIN_ROUTE, component: <Main />},
    {path: INFO_ROUTE + ":id", component: <Redirector />},
    {path: ERROR_ROUTE, component: <Error />}
]