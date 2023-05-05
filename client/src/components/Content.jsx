import React from 'react'
import cl from '../styles/Content.module.css';

export default function Content(props) {
  return (
    <div className={cl.content}>{props.children}</div>
  )
}
