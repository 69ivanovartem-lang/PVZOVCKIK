from fastapi import FastAPI
from pydantic import BaseModel
from typing import List

app = FastAPI()

class Order(BaseModel):
    pzv_number: str
    order_number: str
    client_name: str
    phone_number: str
    status: str

# Теперь данные на русском языке
orders_db = [
    {"pzv_number": "101", "order_number": "ORD-01", "client_name": "Алексей Петров", "phone_number": "+79001112233", "status": "В пути"},
    {"pzv_number": "102", "order_number": "ORD-02", "client_name": "Марина Сидорова", "phone_number": "+79110001122", "status": "Готов к выдаче"},
    {"pzv_number": "103", "order_number": "ORD-03", "client_name": "Иван Иванов", "phone_number": "+79998887766", "status": "Выдан"}
]

@app.get("/orders", response_model=List[Order])
async def get_orders():
    return orders_db

@app.post("/orders/add")
async def add_order(order: Order):
    orders_db.append(order.dict())
    return {"status": "ok", "message": "Заказ успешно добавлен"}