import { observer } from 'mobx-react-lite';
import React, { useContext, useEffect, useState } from 'react'
import { Context } from '..'
import CustomButton from '../components/UI/Buttons/CustomButton/CustomButton'
import AddUrlModal from '../components/UI/modals/AddUrlModal/AddUrlModal';
import Spinner from '../components/UI/Spinner/Spinner';
import Table from '../components/UI/Table/Table'
import { create, deleteLink, getUrls } from '../http/urlApi';

const Main = observer(() => {
    const {user, urls} = useContext(Context);
    const [modalVisible, setModalVisible] = useState(false);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        getUrls().then((data) => {
            urls.setUrls(data);
            setLoading(false);
        })
    }, [])

    const click = (e, url) => {
        e.preventDefault();
        create(url, user.user.id).then(data => {
            if (data.success){
                console.log(data)
                urls.setUrls([...urls.urls, data.url])
            } else {
                alert(data.errors.join("\n"));
            }
        });
    }

    const deleteUrl = (id) => {
        deleteLink(id).then(() => {
            urls.setUrls(urls.urls.filter(x => x.id !== id))
        })
    }

    if(loading){
        return <Spinner />
    }

  return (
    <div style={{width: '100%'}}>
            <AddUrlModal show={modalVisible} click={(e, url) => click(e, url)} onHide={() => setModalVisible(false)} title="Adding new short link"></AddUrlModal>
        {user.isAuth && 
            <CustomButton onClick={() => setModalVisible(true)}>Add new Url</CustomButton>
        }
        <Table deleteUrl={(id) => deleteUrl(id)} data={urls.urls}></Table>
    </div>
  )
});

export default Main;