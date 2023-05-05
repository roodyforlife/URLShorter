import React from 'react'
import cl from '../styles/Form.module.css'

export default function Form(props) {
  return (
    <form style={{minWidth: props.minWidth}} className={cl.form}> 
        <div className={cl.title}><h2>{props.title}</h2></div>
        {props.children}
    </form>
  )
}
