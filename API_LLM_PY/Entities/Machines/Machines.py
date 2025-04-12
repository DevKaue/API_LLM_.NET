from pydantic import BaseModel
from typing import Optional

class Machines(BaseModel):
    id: Optional[str]
    brand: str
    model: str
    description: str

class MachineCreate(BaseModel):
    brand: str
    model: str
    description: str
