import jwt_decode from 'jwt-decode';
import React, { useContext, useState } from 'react'
import { useNavigate } from 'react-router-dom';
import { Context } from '..';
import Form from '../components/Form';
import CustomButton from '../components/UI/Buttons/CustomButton/CustomButton';
import CustomInput from '../components/UI/Inputs/CustomInput/CustomInput';
import { registration } from '../http/userApi';
import { MAIN_ROUTE } from '../utils/consts';

export default function Registration() {
    const [form, setForm] = useState({email: "", password: "", name: ""})
    const {user} = useContext(Context);
    const navigate = useNavigate();

    const click = (event) => {
        event.preventDefault();
        registration(form.email, form.password, form.name).then(data => {
            if (data.success){
                localStorage.setItem('token', data.token)
                user.setUser(jwt_decode(data.token));
                user.setIsAuth(true);
                navigate(MAIN_ROUTE)
            } else {
                alert(data.errors.join("\n"));
            }
        });
    }

  return (
    <Form minWidth={400} title="Registration">
        <CustomInput value={form.email} onChange={(e) => setForm({...form, email: e.target.value})} type="text" title="Email" />
        <CustomInput value={form.name} onChange={(e) => setForm({...form, name: e.target.value})} type="text" title="Name" />
        <CustomInput value={form.password} onChange={(e) => setForm({...form, password: e.target.value})} type="password" title="Password" />
        <CustomButton onClick={click}>Regist account</CustomButton>
    </Form>
  )
}
