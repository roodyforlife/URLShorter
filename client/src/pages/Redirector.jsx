import React, { useContext, useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'
import { Context } from '..';
import { getOne, visit } from '../http/urlApi';
import { ERROR_ROUTE, INFO_ROUTE } from '../utils/consts';
import cl from '../styles/Redirector.module.css';
import CustomButton from '../components/UI/Buttons/CustomButton/CustomButton';
import Spinner from '../components/UI/Spinner/Spinner';

export default function Redirector() {
    const params = useParams();
    const {user, urls} = useContext(Context);
    const navigate = useNavigate();
    const [url, setUrl] = useState(urls.urls.find(x => x.newLink === params.id));
    const [disabled, setDisabled] = useState(true);
    const [seconds, setSeconds] = useState(10);
    const [timerActive, setTimerActive] = useState(true);
    const [loading, setLoading] = useState(true);

    const redirect = async () => {
        window.location.replace(url.link)
    }

    useEffect(() => {
        if (seconds > 0 && timerActive){
            if (!loading){
                setTimeout(setSeconds, 1000, seconds - 1);
            }
        } else {
            setTimerActive(false);
            setDisabled(false);
        }
    }, [seconds, timerActive, loading])

    useEffect(() => {
        getOne(params.id).then((data) => {
            setLoading(false);
            if (data === null){
                navigate(ERROR_ROUTE)
            } else {
                setUrl(data)
            }
        })
    }, [])

    if(loading) {
        return <Spinner />
    }

    return(
        <div className={cl.content}>
            <div className={cl.title}>
                <h2>Click on the button to go to the site</h2>
                <div className={cl.counter}>The button will be available in <span>{seconds}</span> seconds</div>
            </div>
            <CustomButton disabled={disabled} onClick={redirect}>Redirect me</CustomButton>
            {user.isAuth && 
            <div className={cl.information}>
            <div className={cl.item}>
                <span>Old link</span>
                <span>{url.link}</span>
            </div>
            <div className={cl.item}>
                <span>New link</span>
                <span>{`${window.location.origin}/${INFO_ROUTE + url.newLink}`}</span>
            </div>
            <div className={cl.item}>
                <span>Create date</span>
                <span>{new Date(url.createdDate).toDateString()}</span>
            </div>
            <div className={cl.item}>
                <span>Owner</span>
                <span>{url.user.userName}</span>
            </div>
        </div>
            }
        </div>
    )
}
