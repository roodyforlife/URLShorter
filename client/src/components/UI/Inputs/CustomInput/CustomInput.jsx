import React from 'react'
import cl from './CustomInput.module.css'

export default function CustomInput(props) {
  return (
    <div className={cl.content}>
        <span className={cl.title}>{props.title}</span>
        <input className={cl.input} {...props}/>
    </div>
  )
}
