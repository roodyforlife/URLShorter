import React from 'react'
import cl from './CustomButton.module.css';

export default function CustomButton(props) {
  return (
    <button disabled={props.disabled} onClick={props.onClick} className={cl.button}>{props.children}</button>
  )
}
