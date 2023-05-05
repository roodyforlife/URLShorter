import React, { useContext, useState } from 'react'
import Form from '../../../Form';
import CustomButton from '../../Buttons/CustomButton/CustomButton';
import CustomInput from '../../Inputs/CustomInput/CustomInput';
import cl from './AddUrlModal.module.css';

export default function AddUrlModal({title, onHide, show, click}) {
    const [url, setUrl] = useState("");
    if(show)
  return (
    <div className={cl.content} onClick={onHide}>
        <div className={cl.modal} onClick={(e) => e.stopPropagation()}>
        <div className={cl.title}>
          <h3>{title}</h3>
          <span onClick={onHide} className={cl.close}>
            &times;
          </span>
        </div>
        <Form>
            <CustomInput value={url} onChange={(e) => setUrl(e.target.value)} title="Type link" type="text"></CustomInput>
            <CustomButton onClick={(e) => click(e, url)}>Create</CustomButton>
        </Form>
        </div>
    </div>
  )
}
