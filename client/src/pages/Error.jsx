import React from 'react'
import cl from '../styles/Error.module.css';

export default function Error() {
  return (
    <div className={cl.content}>
        <div className={cl.error}>
            <div style={{fontSize: 100}}>404</div>
            <div style={{fontSize: 30}}>Not found</div>
            <div style={{fontSize: 14}}>The resourse could not be found on this server</div>
        </div>
    </div>
  )
}
