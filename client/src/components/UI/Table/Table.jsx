import { observer } from 'mobx-react-lite';
import React, { useContext } from 'react'
import { NavLink, useNavigate } from 'react-router-dom';
import { Context } from '../../..';
import { INFO_ROUTE } from '../../../utils/consts';
import CustomButton from '../Buttons/CustomButton/CustomButton';
import cl from './Table.module.css';

const Table = observer(({data, deleteUrl}) => {
    const {user} = useContext(Context);
    const navigate = useNavigate();

  return (
    <div className={cl.table}>
        <div className={cl.table__header}>
            <div className={cl.item}>
            <div className={cl.string}>Old link</div>
                <div className={cl.string}>New Link</div>
                <div className={cl.string}>CreateDate</div>
                <div className={cl.string}></div>
            </div>
        </div>
        <div className={cl.items}>
            {data.map((data) =>
                <div className={cl.item} key={data.id}>
                    <div className={cl.string}><NavLink to={data.link}>{data.link}</NavLink></div>
                    <div className={cl.string}><NavLink to={window.location + INFO_ROUTE + data.newLink}>{window.location + INFO_ROUTE + data.newLink}</NavLink></div>
                    <div className={cl.string}>{new Date(data.createdDate).toDateString()}</div>
                    {(user.user.id === data.user.id || user.user.roles === "Admin") && <div className={[cl.string, cl.controll].join(" ")}><CustomButton onClick={() => deleteUrl(data.id)}>Delete</CustomButton></div>}
                </div>
            )}
        </div>
    </div>
  )
});

export default Table;